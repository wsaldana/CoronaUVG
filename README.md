# CoronaUVG
Carlos Raxtum 19721
Walter Saldaña 19
Abraham Gutierrez 19

## Instrucciones del uso
Ejecutar la escena Inicio Juego para iniciar el mismo

## Base de datos
El archivo base_datos.csv contiene una base de datos con canciones, sus artistas, el género de cada una, el disco,
la duracion y el año en que cada cancion fue lanzada.

## Aspectos Relevantes para el funcionamiento del sistema
### Dependencias necesarias para el funcionamiento del programa
pandas, sklearn, numpy, matplotlib, seaborn, neo4j, networkx

### Clase base de datos
Dentro del archivo ClaseBaseDeDatosMusica.py leer el archivo .csv con pandas
```
class BaseMusica:
    data = pd.read_csv('base_datos.csv',header=0)
    tfidf = TfidfVectorizer()
    tfidf_matrix = tfidf.fit_transform(data['Genero'])
    cosine_sim = linear_kernel(tfidf_matrix, tfidf_matrix)
    indices = pd.Series(data.index, index=data['Cancion']).drop_duplicates()
    
```
### Para cargar el programa es necesario importar los siguientes paquetes
Dentro del archivo ClaseBaseDeDatosMusica.py
```
import pandas as pd 
import numpy as np  

from sklearn import tree
from sklearn.tree import DecisionTreeClassifier
from sklearn.model_selection import train_test_split

from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics.pairwise import linear_kernel

from matplotlib import pyplot as plt
import seaborn as sns
    
```
Dentro del archivo Grafo.py
```
import networkx as nx
import matplotlib.pyplot as plt
    
```
