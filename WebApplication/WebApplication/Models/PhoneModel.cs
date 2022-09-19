using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication.Models {
    public class PhoneModel {
        private List<Phone> _phones = new List<Phone>();
        public List<Phone> phones { 
            get { 
                return _phones;
            }
            private set { 
                _phones = value;
            }
        }
        private readonly string _path;
        public PhoneModel(string path) {
            _path = path;
            if (!File.Exists(_path))
                return;
            using (var fs = new StreamReader(path)) {
                var jsonTextReader = new JsonTextReader(fs);
                var jsonSerializer = new JsonSerializer();
                phones = jsonSerializer.Deserialize<List<Phone>>(jsonTextReader);
                //TODO:
                //здесь должна быть сортировка элементов 
            }
        }
        public void Add(string surName, string phoneNumber) {
            Phone phone = new Phone() { Id = Guid.NewGuid(), surName = surName, phoneNumber = phoneNumber };
            phones.Add(phone);
            Save();
        }
        private void Save() {
            var serializer = new JsonSerializer();
            using (JsonWriter writer = new JsonTextWriter(new StreamWriter(_path))) {
                serializer.Serialize(writer, phones);
            }
        }
        public void Delete(Guid id) {
            var person = phones.FirstOrDefault(x => x.Id == id);
            if (person == null)
                return;
            phones.Remove(person);
            Save();
        }
    }
}