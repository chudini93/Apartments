# Apartments

## Table of contents
* [Overview](#overview)
* [Prerequisites](#prerequisites)
* [Technologies](#technologies)
* [Setup](#setup)

## Overview
1. Ściągnij zestaw danych z poniższego linku i wypisz je na konsoli
http://net-poland-interview-stretto.us-east-2.elasticbeanstalk.com/api/flats/csv
2. Sparsuj ściągniety zestaw danych do obiektu i wyświetl rezultat na konsoli
3. Dla każdego miasta znajdź największe mieszkanie typu ‘Residential’ i wyświetl rezultaty na konsoli
4. Znajdź najtańsze mieszkanie z największą ilością pomieszczeń (beds and baths) i wyświetl rezultat na konsoli
5. Dla każdego miasta znajdź najdroższe mieszkanie uwzględniając podatek (price with tax = price + price*tax), który możesz pobrać pod linkiem:
http://net-poland-interview-stretto.us-east-2.elasticbeanstalk.com/api/flats/taxes?city=cityName (zamieniając cityName na nazwę miasta, np. GREENWOOD) i wyświetl rezultaty na konsoli (włączając nową cenę z podatkiem)

## Prerequisites
* Visual Studio 2019
* .NET Core 5.0

## Technologies
* C#
* .NET Core 5.0
* CSV Parser - Sylvan.Data.Csv

## Setup
To run / build application we simply start application in Visual Studio. 
As for environment application to be run needs Windows or Linux as operating system (preferred Windows)