using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Stretto.ConsoleApp.Attributes;
using Stretto.ConsoleApp.Exceptions;
using Stretto.ConsoleApp.Extensions;
using Sylvan.Data.Csv;

namespace Stretto.ConsoleApp.Services.Base
{
    public abstract class GenericCsvParserService<T> where T : class, new()
    {
        protected async Task<IList<T>> ParseCsvAsync(string csvContent)
        {
            var output = new List<T>();

            using (TextReader tReader = new StringReader(csvContent))
            {
                // Using Sylvan.Data.csv
                // High performance CSV parser based on: https://www.joelverhagen.com/blog/2020/12/fastest-net-csv-parsers
                using var csv = await CsvDataReader.CreateAsync(tReader);
                int rowNumber = 1;
                while (await csv.ReadAsync())
                {
                    try
                    {
                        T instance = CreateObjectFromCsvLine(csv);
                        output.Add(instance);
                    }
                    catch (Exception ex)
                    {
                        // TODO: Replace with logger and decide if it should break the execution or not.
                        Console.WriteLine($"Invalid row [{rowNumber}]: {ex.Message}");
                        continue;
                    }
                    finally
                    {
                        rowNumber++;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Creates object of type <see cref="T"/> based on custom attribute property <see cref="CsvName.Name"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="csvLine"></param>
        /// <returns></returns>
        protected T CreateObjectFromCsvLine(CsvDataReader csvLine)
        {
            var output = new T();

            for (int i = 0; i < csvLine.FieldCount - 1; i++)
            {
                string headerName = csvLine.GetName(i);

                PropertyInfo propWithMatchingCsvName = typeof(T)
                    .GetProperties()
                    .FirstOrDefault(x => CustomAttributeExtensions.GetCustomAttribute<CsvName>((MemberInfo) x)?.Name == headerName);

                if (propWithMatchingCsvName == null)
                    throw new CsvNameAttributeNotFoundException(
                        $"Name: {headerName} could not be found for type {typeof(T)}");


                if (propWithMatchingCsvName.PropertyType == typeof(string))
                {
                    string value = csvLine.GetString(i);
                    if (headerName == "state")
                    {
                        value = value.ToStateName();
                    }
                    propWithMatchingCsvName.SetValue(output, value);
                }
                else if (propWithMatchingCsvName.PropertyType == typeof(int))
                {
                    propWithMatchingCsvName.SetValue(output, csvLine.GetInt32(i));
                }
                else if (propWithMatchingCsvName.PropertyType == typeof(decimal))
                {
                    propWithMatchingCsvName.SetValue(output, csvLine.GetDecimal(i));
                }
                else if (propWithMatchingCsvName.PropertyType == typeof(float))
                {
                    propWithMatchingCsvName.SetValue(output, csvLine.GetFloat(i));
                }
                else if (propWithMatchingCsvName.PropertyType == typeof(DateTime))
                {
                    propWithMatchingCsvName.SetValue(output, csvLine.GetString(i).ToDateTime());
                }
            }

            return output;
        }
    }
}