using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Config {
    // Mongo DB Docker command:
    // With admin (root) user:
    // docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
    // With specific user
    // docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=password1 mongo
    // Run docker image in specific network
    // docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME = mongoadmin - e MONGO_INITDB_ROOT_PASSWORD=password1 --network=net5tutorial mongo

    // Run docker image with overwriting enviorment variables (we can't connect to mongodb at localhost in the container)
    // docker run -it -p 8080:80 -e MongoDBSettings:Host=mongo -e MongoDBSettings:Password=password --network=net5tutorial catalog:v1

    public class MongoDBSettings {
        public string host { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string connectionString { 
            get {
                return $"mongodb://{this.host}:{this.port}";
                //return $"mongodb://{this.username}:{this.password}@{this.host}:{this.port}";
            }
        }
    }
}
