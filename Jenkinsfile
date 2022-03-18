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
                        sh "docker-compose down"
                    }
                    finally { }
                }
            }
        }
        stage("Deploy") {
            steps {
                sh "docker-compose up -d --build"
            }
        }
    }
}