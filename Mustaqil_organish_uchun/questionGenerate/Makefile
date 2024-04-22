IMAGE_NAME := sharpistai
STACK_NAME := sharpistai

.PHONY: build deploy

build:
	docker build -t $(IMAGE_NAME) .

deploy:
	docker stack deploy -c docker-compose.yml $(STACK_NAME)
