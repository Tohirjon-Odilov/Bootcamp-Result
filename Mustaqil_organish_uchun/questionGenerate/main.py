
import json
import logging
import os
from fastapi import FastAPI, HTTPException
import requests
from openai import AzureOpenAI
import re, logging, sys, requests, json, time
from pydantic import BaseModel
from typing import List
from fastapi.responses import JSONResponse
from fastapi.encoders import jsonable_encoder
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()



app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["GET", "POST", "PUT", "DELETE"],
    allow_headers=["*"],
)


client = AzureOpenAI(
    api_key="5b0048ed2ba744b88eeee69c01adcc17",
    api_version="2024-02-01",
    azure_endpoint="https://sharpist-oai.openai.azure.com/"
)

logging.basicConfig(stream=sys.stdout, level=logging.INFO,
        format="[%(asctime)s] %(message)s", datefmt="%m/%d/%Y %I:%M:%S %p %Z")
logger = logging.getLogger(__name__)



DEPLOYMENT_NAME='gpt-35-turbo'
SUBSCRIPTION_KEY = 'a43a4bc9c9b246be92c268e4d9e90ada'
SERVICE_REGION = "westeurope"
NAME = "Simple avatar synthesis"
DESCRIPTION = "Simple avatar synthesis description"
SERVICE_HOST = "customvoice.api.speech.microsoft.com"



def generate_questions(text, question_type, question_count, question_difficulty):
    deployment_name = 'gpt-35-turbo'
    prompt = f"Generate {question_count} {question_type} questions about {text}, difficulty: {question_difficulty}."
    response = client.chat.completions.create(
        model=deployment_name,
        temperature=0.7,
        max_tokens=400,
        messages=[
            {"role": "system",
             "content": 
            '''You are questionnaire generator, and you need to generate questionnaire based on question type with correct answer. Each time you need to generate different questions since different users will use this program. Always include answers with questions. When you generate true false questions remove  True or False: from the begining instead put question and add correct answer in brackets like True or False. When you generate multiple case type question you need to generate questions always in this form:
             
            1. What did Elon Musk say about Tesla and Bitcoin?
            a) Tesla will not accept payments in Bitcoin because of environmental concerns.
            b) Tesla will start accepting payments in Bitcoin from now on.
            c) Tesla will accept payments in Bitcoin, but only on weekends.
            Answer: a.

            When you generate short answer type questions include correct answer like correct answer: 
            and correct answer shoud be no more than 3 wods'''}, 
            {"role": "user", "content": prompt}
        ]
    )

    generated_questions = response.choices[0].message.content.strip().split("\n")
    print(generated_questions)
    test_list = [i for i in generated_questions if i]
    # print(test_list)
    return test_list



def parse_generated_questions(generated_questions):
    questions = []
    current_question = {}
    answer_patterns = r'^(correct|Correct) (answer|Answer):|^answer:|^Answer:'

    for line in generated_questions:
        if re.match(r'^\d+\..+', line):
            if current_question:
                questions.append(current_question)
            question_parts = line.split('.', 1)
            current_question = {'question': question_parts[1].strip(), 'options': []}
        elif re.match(r'^[A-Za-z]\.|[A-Za-z]\)[\s]', line):  # Match both formats of options
            current_question['options'].append(line.strip())
        elif re.match(answer_patterns, line):
            current_question['answer'] = line.split(':', 1)[1].strip()
            questions.append(current_question)
            current_question = None

    return questions



def parse_true_false_questions(true_false_questions):
    questions = []

    for statement in true_false_questions:
        question_parts = statement.split('. (')
        question_text = question_parts[0].strip()
        answer_text = question_parts[1].strip(')')

        question_number, question_text = question_text.split('. ', 1)

        if answer_text == 'True':
            answer = True
        elif answer_text == 'False':
            answer = False
        else:
            raise ValueError("Answer should be either 'True' or 'False'")

        question = {
            'question': question_text,
            'answer': answer
        }

        questions.append(question)

    return questions


def parse_short_answer_questions(short_answer_questions):
    questions = []
    temp_question = {}

    for entry in short_answer_questions:
        if re.match(r'^\d+\.', entry):  
            if temp_question.get('question') and temp_question.get('answer'):
                questions.append(temp_question)
                temp_question = {}

            first_dot_index = entry.find('.')
            question_text = entry[first_dot_index + 1:].strip()
            temp_question['question'] = question_text
            if "(correct answer:" in question_text:
                split_text = question_text.split("(correct answer:")
                temp_question['question'] = split_text[0].strip()
                temp_question['answer'] = split_text[1].strip(')').strip()
        elif re.match(r'^(Correct answer:|correct answer:)', entry):
            answer_text = entry.split(':', 1)[1].strip()
            temp_question['answer'] = answer_text

    if temp_question.get('question') and temp_question.get('answer'):
        questions.append(temp_question)

    return questions





@app.get("/generate_questions/")
async def generate_api_questions(text: str, question_type: str, question_count: int, question_difficulty: str):
    if question_type not in ["multiple choice", "true false", "short answer"]:
        raise HTTPException(status_code=400, detail="Invalid question type. Supported types: 'multiple choice', 'true false', 'short answer'")

    generated_questions = generate_questions(text, question_type, question_count, question_difficulty)

    if question_type == "multiple choice":
        parsed_questions = parse_generated_questions(generated_questions)
        format_value = 1
    elif question_type == "true false":
        parsed_questions = parse_true_false_questions(generated_questions)
        format_value = 2
    elif question_type == "short answer":
        parsed_questions = parse_short_answer_questions(generated_questions)
        format_value = 3

        

    response_data = {"questions": parsed_questions, "format": format_value}

    return JSONResponse(content=jsonable_encoder(response_data))




@app.get("/check_answers/")
async def generate_api_questions(question: str, correct: str, user: str):
    questions_and_answers = [
    {"Question": question, "GivenAnswer": user, "CorrectAnswer": correct},
]
    questions_and_answers_string = str(questions_and_answers)
    response = client.chat.completions.create(
        model=DEPLOYMENT_NAME,
        temperature=0.7,
        max_tokens=400,
        messages=[
            {"role": "system", "content": 'You are an assistant, that checks answers and based on wrong ones generates educating texts on easy to understand language. Not longer than 5 sentences.'},
            {"role": "user", "content": questions_and_answers_string} #Replace the hard-coded text with your prompt, containing wrong answers and task to explain correct solutions on easy to understand language
        ]
    )

    logging.basicConfig(stream=sys.stdout, level=logging.INFO,
            format="[%(asctime)s] %(message)s", datefmt="%m/%d/%Y %I:%M:%S %p %Z")
    logger = logging.getLogger(__name__)

    gptresponse = response.choices[0].message.content
    print("Response: " + gptresponse + "\n")


    logger.info("Response: " + gptresponse + "\n")

    job_id = submit_synthesis(gptresponse)
    if job_id is not None:
        while True:
            response = get_synthesis(job_id)
            status = response['status']
            if status == 'Succeeded':
                logger.info('batch avatar synthesis job succeeded')
                url = response["outputs"]["result"]
                response_data = {"url": url}
                
                return JSONResponse(content=jsonable_encoder(response_data))
            elif status == 'Failed':
                logger.error('batch avatar synthesis job failed')
                raise HTTPException(status_code=500, detail="batch avatar synthesis job failed")
            else:
                logger.info(f'batch avatar synthesis job is still running, status [{status}]')
                time.sleep(5)



def submit_synthesis(gptresponse):
    url = f'https://{SERVICE_REGION}.{SERVICE_HOST}/api/texttospeech/3.1-preview1/batchsynthesis/talkingavatar'
    header = {
        'Ocp-Apim-Subscription-Key': SUBSCRIPTION_KEY,
        'Content-Type': 'application/json'
    }

    payload = {
        'displayName': NAME,
        'description': DESCRIPTION,
        "textType": "PlainText",
        'synthesisConfig': {
            "voice": "en-US-JennyNeural",
        },
        'customVoices': {
        },
        "inputs": [
            {
                "text": gptresponse,
            },
        ],
        "properties": {
            "customized": False,
            "talkingAvatarCharacter": "lisa",
            "talkingAvatarStyle": "graceful-sitting",
            "videoFormat": "webm",
            "videoCodec": "vp9",
            "subtitleType": "soft_embedded",
            "backgroundColor": "transparent",
        }
    }

    response = requests.post(url, json.dumps(payload), headers=header)
    if response.status_code < 400:
        logger.info('Batch avatar synthesis job submitted successfully')
        logger.info(f'Job ID: {response.json()["id"]}')
        return response.json()["id"]
    else:
        logger.error(f'Failed to submit batch avatar synthesis job: {response.text}')

def get_synthesis(job_id):
    url = f'https://{SERVICE_REGION}.{SERVICE_HOST}/api/texttospeech/3.1-preview1/batchsynthesis/talkingavatar/{job_id}'
    header = {
        'Ocp-Apim-Subscription-Key': SUBSCRIPTION_KEY
    }
    response = requests.get(url, headers=header)
    if response.status_code < 400:
        logger.debug('Get batch synthesis job successfully')
        logger.debug(response.json())
        return response.json()
    else:
        logger.error(f'Failed to get batch synthesis job: {response.text}')
  
def list_synthesis_jobs(skip: int = 0, top: int = 100):
    """List all batch synthesis jobs in the subscription"""
    url = f'https://{SERVICE_REGION}.{SERVICE_HOST}/api/texttospeech/3.1-preview1/batchsynthesis/talkingavatar?skip={skip}&top={top}'
    header = {
        'Ocp-Apim-Subscription-Key': SUBSCRIPTION_KEY
    }
    response = requests.get(url, headers=header)
    if response.status_code < 400:
        logger.info(f'List batch synthesis jobs successfully, got {len(response.json()["values"])} jobs')
        logger.info(response.json())
    else:
        logger.error(f'Failed to list batch synthesis jobs: {response.text}')
  

class QuestionAnswer(BaseModel):
    Question: str
    GivenAnswer: str
    CorrectAnswer: str
    
