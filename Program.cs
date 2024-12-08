using System.Diagnostics;
using System.Text.Json;

namespace Reflection;

class Program
{
    static void Main(string[] args)
    {
        // Написать сериализацию свойств или полей класса в строку
        // Проверить на классе: class F { int i1, i2, i3, i4, i5; Get() => new F(){ i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 }; }
        F f = F.Get();
        string serializeString = "";
        int numberIterations = 100000;

        // Замерить время еще раз и вывести в консоль сколько потребовалось времени на вывод текста в консоль
        Stopwatch watchSerializerPrint = Stopwatch.StartNew();
        for (var i = 0; i < numberIterations; i++)
        {
            serializeString = Serializer.SerializeFromObjectToCSV(f);
            Console.WriteLine(serializeString);
        }
        watchSerializerPrint.Stop();
        Console.WriteLine($"SerializeFromObjectToCSV: {watchSerializerPrint.ElapsedMilliseconds} milliseconds for {numberIterations} iterations with console output");
        Console.WriteLine();

        // Замерить время до и после вызова функции (для большей точности можно сериализацию сделать в цикле 100-100000 раз)
        Stopwatch watchSerializer = Stopwatch.StartNew();
        for (var i = 0; i < numberIterations; i++)
        {
            serializeString = Serializer.SerializeFromObjectToCSV(f);
        }
        watchSerializer.Stop();
        // Вывести в консоль полученную строку и разницу времен
        Console.WriteLine(serializeString);
        // Отправить в чат полученное время с указанием среды разработки и количества итераций
        Console.WriteLine($"SerializeFromObjectToCSV: {watchSerializer.ElapsedMilliseconds} milliseconds for {numberIterations} iterations without console output");
        Console.WriteLine();

        // Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
        // И тоже посчитать время и прислать результат сравнения
        string serializeJsonString = "";
        Stopwatch stopwatchJson = Stopwatch.StartNew();
        for (var i = 0; i < numberIterations; i++)
        {
            serializeJsonString = JsonSerializer.Serialize(f);
        }
        stopwatchJson.Stop();
        Console.WriteLine($"JsonSerializer.Serialize: {stopwatchJson.ElapsedMilliseconds} milliseconds for {numberIterations} iterations");
        Console.WriteLine();

        Stopwatch stopwatchJsonDeserialize = Stopwatch.StartNew();
        for (var i = 0; i < numberIterations; i++)
        {
            var obj = JsonSerializer.Deserialize<F>(serializeJsonString);
        }
        stopwatchJsonDeserialize.Stop();
        Console.WriteLine($"JsonSerializer.Deserialize: {stopwatchJsonDeserialize.ElapsedMilliseconds} milliseconds for {numberIterations} iterations");
        Console.WriteLine();

        // Написать десериализацию/загрузку данных из строки (ini/csv-файла) в экземпляр любого класса
        // Замерить время на десериализацию
        Stopwatch watchDeserialize = Stopwatch.StartNew();
        for (var i = 0; i < numberIterations; i++)
        {
            var result = Serializer.DeserializeFromCSVToObject(serializeString);
        }
        watchDeserialize.Stop();
        Console.WriteLine($"DeserializeFromCSVToObject: {watchDeserialize.ElapsedMilliseconds} milliseconds for {numberIterations} iterations");
        Console.WriteLine();

        // Общий результат прислать в чат с преподавателем в системе в таком виде:
        Console.WriteLine($@"Сериализуемый класс: class F {{ int i1, i2, i3, i4, i5;}}
код сериализации-десериализации: ...
количество замеров: {numberIterations} итераций
мой рефлекшен:
Время на сериализацию = {watchSerializer.ElapsedMilliseconds} мс
Время на десериализацию = {watchDeserialize.ElapsedMilliseconds} мс
стандартный механизм:
Время на сериализацию = {stopwatchJson.ElapsedMilliseconds} мс
Время на десериализацию = {stopwatchJsonDeserialize.ElapsedMilliseconds} мс");
    }
}