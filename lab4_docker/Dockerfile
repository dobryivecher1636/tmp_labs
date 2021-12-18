FROM python:3
WORKDIR /app
ADD lab1.py /
RUN python3 -m venv env
CMD ['source', 'env/bin/activate']
ENTRYPOINT ["python3", "/lab1.py"]