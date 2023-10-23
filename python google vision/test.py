import io
import os

from google.cloud import vision
from google.cloud.vision_v1 import types

os.environ['GOOGLE_APPLICATION_CREDENTIALS'] = r'friendly-storm-402818-50a65a800956.json'

client = vision.ImageAnnotatorClient()

file_name = os.path.abspath(r'C:\Users\User\source\repos\TesseracDemo\python google vision\prueba.jpeg')

#reading in the image file to memory
with io.open(file_name,'rb') as image_file:
    content = image_file.read()

# setting the image 
image = types.Image(content=content)

# making the request to vision 
response = client.text_detection(image=image)
texts = response.text_annotations
print("Texts:")

try:
  print(texts[0].description)
except:
  print("An exception occurred") 


# for text in texts:
#     print(f'\n"{text.description}"')

#     vertices = [
#         f"({vertex.x},{vertex.y})" for vertex in text.bounding_poly.vertices
#     ]

#     print("bounds: {}".format(",".join(vertices)))

if response.error.message:
    raise Exception(
        "{}\nFor more info on error messages, check: "
        "https://cloud.google.com/apis/design/errors".format(response.error.message)
    )
