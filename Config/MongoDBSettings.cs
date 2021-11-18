using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Config {
    // Mongo DB Docker command:
    // docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
    public class MongoDBSettings {
        public string host { get; set; }
        public string port { get; set; }

        public string connectionString { 
            get {
                return $"mongodb://{this.host}:{this.port}";
            }
        }
    }
}
