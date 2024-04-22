
import json
import logging
import os
import sys
import time
from pathlib import Path
from openai import AzureOpenAI

import requests

client = AzureOpenAI(
    api_key="5b0048ed2ba744b88eeee69c01adcc17",  
    api_version="2024-02-01",
    azure_endpoint = "https://sharpist-oai.openai.azure.com/"
    )
    
deployment_name='gpt-35-turbo'
questions_and_answers = [
    {"Question": "How much is 1 + 1?", "GivenAnswer": "3", "CorrectAnswer": "2"},
    {"Question": "What color is the sky?", "GivenAnswer": "Blue", "CorrectAnswer": "Blue"},
    {"Question": "Who wrote 'Romeo and Juliet'?", "GivenAnswer": "Shakespeare", "CorrectAnswer": "Shakespeare"},
]
questions_and_answers_string = str(questions_and_answers)
response = client.chat.completions.create(
    model=deployment_name,
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



SUBSCRIPTION_KEY = 'a43a4bc9c9b246be92c268e4d9e90ada'
SERVICE_REGION = "westeurope"

NAME = "Simple avatar synthesis"
DESCRIPTION = "Simple avatar synthesis description"


SERVICE_HOST = "customvoice.api.speech.microsoft.com"


def submit_synthesis():
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
        if response.json()['status'] == 'Succeeded':
            logger.info(f'Batch synthesis job succeeded, download URL: {response.json()["outputs"]["result"]}')
        return response.json()['status']
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
  
  
if __name__ == '__main__':
    job_id = submit_synthesis()
    if job_id is not None:
        while True:
            status = get_synthesis(job_id)
            if status == 'Succeeded':
                logger.info('batch avatar synthesis job succeeded')
                break
            elif status == 'Failed':
                logger.error('batch avatar synthesis job failed')
                break
            else:
                logger.info(f'batch avatar synthesis job is still running, status [{status}]')
                time.sleep(5)