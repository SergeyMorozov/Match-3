# Тестовое задание

Казуальная игра жанра «триврядка» упрощенной модели<br>
Unity version: 6000.0.21f1

![Gameplay](https://github.com/SergeyMorozov/Match-3/blob/main/Assets/_Game%20UI/-%20%20Sprites/Screens/Screenshot_1.png)
![Gameplay](https://github.com/SergeyMorozov/Match-3/blob/main/Assets/_Game%20UI/-%20%20Sprites/Screens/Screenshot_2.png)

## Описание
Поле размера 10-12 заполняется разными элементами. Игрок тапом по объекту «схлопывает» его и все одноцветные с ним объекты, которые соприкасаются с ним по горизонтали и вертикали.<br>
Тап по объекту стоит 3 очка + T, где Т  - кол-во ходов которое сделал за время игры игрок. Каждый схлопнувшийся шарик дает 1 очко.<br>
Изначально у игрока 10 очков.<br>
Игра заканчивается если кол-во очков сократилось до нуля.<br>
Кол-во полученных за время игры очков (без учета расходов на тапы игрока) считается победным счетом. Если итоговый счет попадает в тройку рекордсменов, то он заносится в файл с рекордами.

## Точка входа
* GameLogicEntryPoint.cs - Точка входа в игру

## Особенности
* Новая модульная архитектура проекта
* Испоолзуемые паттерны MVC, Object Pooling for Unity

## Архитектура проекта
В проекте используется новая модульная архитектура. Каждый модуль имеет свою <b>Систему</b> которая управляет своим типом объектов.<br>
Чётко разделены <b>Данные</b> и <b>Логика</b>. Каждая система управляет своими данными с помощью своих скриптов логики. <b>Системы</b> между собой общаются только с помощью <b>Событий</b>.<br>
 
Например <b>Board System</b> имеет следующую структуру:
![Project](https://github.com/SergeyMorozov/Match-3/blob/main/Assets/_Game%20UI/-%20%20Sprites/Screens/Screenshot_3.png)
* <b>Board Data</b> - содержит данные относящиеся с данной системе
* <b>Board Events</b> - содержит события системы
* <b>Board Settings</b> - настройки системы
<br>
Каждый скрипт логики отвечает только за конкретную часть задачи игрового поля.<br>
Все остальные системы построены по такой же схеме. Это упрощает разработку. Расширение проекта происходит простым добавлением новой <b>Системы</b>, которая никак не пересекается с уже существующими.<br>
Нет единой точки связи всех систем. Каждая <b>Система</b> работает параллельно и независимо от других.
