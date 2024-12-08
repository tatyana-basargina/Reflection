Рефлексия и её применение

Цель:
Написать свой класс-сериализатор данных любого типа в формат CSV, сравнение его быстродействия с типовыми механизмами серализации.
Полезно для изучения возможностей Reflection, а может и для применения данного класса в будущем.


Описание/Пошаговая инструкция выполнения домашнего задания:
Основное задание:

Написать сериализацию свойств или полей класса в строку
Проверить на классе: class F { int i1, i2, i3, i4, i5; Get() => new F(){ i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 }; }

Замерить время до и после вызова функции (для большей точности можно сериализацию сделать в цикле 100-100000 раз)

Вывести в консоль полученную строку и разницу времен

Отправить в чат полученное время с указанием среды разработки и количества итераций

Замерить время еще раз и вывести в консоль сколько потребовалось времени на вывод текста в консоль

Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
И тоже посчитать время и прислать результат сравнения

Написать десериализацию/загрузку данных из строки (ini/csv-файла) в экземпляр любого класса
Замерить время на десериализацию

Общий результат прислать в чат с преподавателем в системе в таком виде:

Сериализуемый класс: class F { int i1, i2, i3, i4, i5;}
код сериализации-десериализации: Reflection.Serializer
количество замеров: 100000 итераций
мой рефлекшен:
Время на сериализацию = 33 мс
Время на десериализацию = 50 мс
стандартный механизм:
Время на сериализацию = 57 мс
Время на десериализацию = 17 мс