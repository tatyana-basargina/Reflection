using System.Reflection;
using System.Text;

namespace Reflection;

/// <summary> Serializer </summary>
public static class Serializer
{
    /// <summary> Serialize from object to CSV </summary>
    /// <param name="obj">any object</param>
    /// <returns>CSV</returns>
    public static string SerializeFromObjectToCSV(object obj)
    {
        StringBuilder result = new StringBuilder();

        foreach (var item in obj.GetType()
                     .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            result.Append($"{item.GetValue(obj)};");
        }

        return result.ToString();
    }

    /// <summary> Deserialize from CSV to object</summary>
    /// <param name="csv">string in CSV format</param>
    /// <returns>object</returns>
    public static object DeserializeFromCSVToObject(string csv)
    {
        var result =  Activator.CreateInstance(typeof(F));
        var i = 0;
        string?[] arrValuesCsv = csv.Split(";");

        foreach (var item in result!.GetType()
                     .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            item.SetValue(result, Convert.ChangeType(arrValuesCsv[i], item.FieldType));
            i++;
        }

        return result;
    }
}