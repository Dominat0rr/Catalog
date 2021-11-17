Video title: .NET 5 REST API Tutorial - Build From Scratch With C#
Video URL: https://www.youtube.com/watch?v=ZXdFisA_hOY
Get code URL: https://www.youtube.com/redirect?event=video_description&redir_token=QUFFLUhqa29tS3VCeHUzTHhGejlEYmhBd1lpdmFHOVNFQXxBQ3Jtc0trVWlYWWozay1uaGFfNUd0c3hxZ0tIWEhjald6a1AyVlhIanh0VEUxcnBmZ2JzNG9IenZIUkc5dlRSMDJZdGtzUFQwcFNJeVZmNTVaODBZclp6UkJ5UExvbFdINkdYbG5UOGVhTnFFZk94X1lsb1FTTQ&q=https%3A%2F%2Fyoutube.dotnetmicroservices.com%2Fnet5restapi-10

Timestamps:
⭐️ Course Contents ⭐️
Getting Started
0:00:00 Introduction
0:03:02 Creating the project
0:04:01 Exploring the generated project files
0:10:03 Trusting the self-signed certificate
0:11:36 Exploring the default Swagger UI page
0:12:30 Configuring Visual Studio Code settings

Entity, Repository, Controller GET
0:14:33 Introduction
0:15:45 Adding an entity
0:20:39 Ading an in-memory repository
0:26:40 Creating the controller
0:30:42 Implemeting GET all items
0:33:37 Implemeting GET single item
0:37:47 Returning a 404 NotFound status code

Dependency Injection, DTOSs
0:39:57 Introduction
0:41:23 What is dependency injection?
0:46:14 Extracting the repository interface
0:47:44 Injecting the repository into the controller
0:48:53 Registering the repository as a singleton
0:52:32 Adding a Data Transfer Object DTO
0:55:46 Creating the AsDto extension method

POST, PUT, DELETE
0:58:59 Introduction
0:59:45 Implementing POST
1:07:39 Adding validations via data annotations
1:10:00 Implemeting PUT
1:17:33 Implementing DELETE

Persisting Entities with MongoDB
1:20:46 Introduction
1:24:44 Using Postman
1:27:53 Creating a MongoDB repository
1:29:42 Using the MongoDB.Driver NuGet package
1:33:28 Implementing MongoDB Create
1:33:57 Running the MongoDB Docker container
1:38:47 Configuring MongoDB connection settings
1:42:38 Registering the MongoClient singleton
1:48:02 Testing the MongoDB integration
1:50:04 Exploring the created database in VS Code
1:52:45 Implemeting MongoDB Get, Update and Delete

Tasks, Async and Await
2:02:27 Introduction
2:06:46 Using the Async suffix
2:09:04 Using tasks in the repository
2:11:50 Using async and await
2:14:28 Returning completed tasks
2:18:16 Using tasks in the controller
2:21:23 Testing async methods in Postman

Secrets and Health Checks
2:27:02 Introduction
2:30:06 Enabling authentication in MongoDB
2:33:36 Using the .NET Secret Manager
2:36:40 Using the MongoDB credentials in the service
2:40:00 Introduction to Health Checks
2:42:28 Adding an endpoint for health checks
2:44:46 Adding a MongoDB health check
2:48:41 Adding checks for readiness and liveness
2:53:51 Customizing the health check response
2:58:59 Exploring other health check NuGet packages

Docker
3:00:44 Introduction
3:08:28 What is Docker?
3:17:54 Removing https redirection
3:20:39 Generating a Dockerfile in VS Code
3:30:40 Building the Docker image
3:33:00 Adding a Docker network
3:34:07 Running the containers in the Docker network
3:40:36 Running the REST API in Docker
3:42:02 Pushing the container image to Docker Hub
3:46:02 Exploring the image in Docker Hub
3:46:32 Pulling the image back to the local box

Kubernetes
3:49:20 Introduction
3:54:05 What is Kubernetes?
4:04:06 Enabling a Kubernetes cluster in Docker Desktop
4:06:12 Installing the Kubernetes extension for VS Code
4:06:58 Declaring the REST API Kuberentes deployment
4:14:35 Creating a secret in Kubernetes
4:17:28 Declaring health probes
4:19:14 Declaring the REST API Kubernetes service
4:22:56 Creating the REST API resources in Kubernetes
4:26:15 Declaring the MongoDB Kubernetes StatefulSet
4:36:09 Declaring the MongoDB Kubernetes service
4:38:27 Creating the MongoDB resources in Kubernetes
4:40:42 Testing the REST API hosted in Kubernetes
4:42:08 Exploring the Kubernetes self-healing capability
4:46:04 Scaling Kubernetes pods
4:47:38 Adding logs via ILogger
4:52:04 Getting a new image version into Kubernetes
4:53:23 Load balancing requests across pods

Unit Testing and TDD
4:56:23 Introduction
4:57:04 What is unit testing?
5:01:19 What is test driven development?
5:04:25 Restructuring files and directories
5:08:25 Creating the xUnit test project
5:09:15 Building multiple projects in VS Code
5:13:10 Adding NuGet packages for unit testing
5:14:35 Testing GetItemAsync unexisting item
5:18:35 Using the AAA pattern
5:19:31 Stubbing dependencies via Moq
5:26:52 Running tests in VS Code
5:28:05 Using the .NET Core Test Explorer extension
5:30:55 Testing GetItemAsync existing item
5:38:01 Using FluentAssertions
5:41:46 Testing GetItemsAsync
5:45:41 Testing CreateItemAsync
5:53:13 Testing UpdateItemAsync
5:57:51 Testing DeleteItemAsync
5:59:40 Refactoring and catching regressions
6:10:50 Using TDD to test a yet to be created method
6:19:07 Going back to green by fixing the failing test
6:21:19 Testing the new controller method in Postman