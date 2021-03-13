using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    class FileIOService
    {
        //Получение пути файла
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }

        //Загрузка данных после Json парса
        public BindingList<ToDoModels> LoadData()
        {
            //Проверка на существование файла
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModels>();
            }
            //Считывание данных
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModels>>(fileText);
            }
        }

        //Сохрание в файл
        public void SaveData(object toDoList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(toDoList);
                writer.Write(output);
            }
        }
    }
}
