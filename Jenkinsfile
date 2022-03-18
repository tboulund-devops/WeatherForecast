pipeline{
    agent any
    stages{
        stage("Build API"){
            steps{
                dir("API") {
                    sh "dotnet build --configuration Release"
                }
            }
        }
        stage("Unit Tests") {
            steps {
                echo "Here we'll run unit tests later"
            }
        }
        stage("Clean containers") {
            steps {
                script {
                    try {
                        sh "docker rm -f weather-web-container"
                        sh "docker rm -f weather-api-container"
                        sh "docker rm -f weather-db-container"
                    }
                    finally { }
                }
            }
        }
        stage("Deploy") {
            parallel {
                stage("Frontend") {
                    steps {
                        dir("Web") {
                            sh "docker build -t weather-web ."
                            sh "docker run --name weather-web-container -d -p 8090:80 weather-web"
                        }
                    }
                }
                stage("API") {
                    steps {
                        dir("API") {
                            sh "docker build -t weather-api ."
                            sh "docker run --name weather-api-container -d -p 8091:80 weather-api"
                        }
                    }
                }
                stage("Database") {
                    steps {
                        sh "docker run --name weather-db-container -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrongP@ssword' -p 8092:1433 -d mcr.microsoft.com/mssql/server:"
                    }
                }
            }
        }
    }
}