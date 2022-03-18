pipeline{
    agent any
    stages{
        stage("Build frontend") {
            when {
                changeset "Web/**"
            }
            steps {
                sh "docker-compose build web"
            }
        }
        stage("Build API"){
            when {
                anyOf {
                    changeset "API/**"
                    changeset "BLL/**"
                    changeset "DAL/**"
                }
            }
            steps {
                dir("API") {
                    sh "dotnet build --configuration Release"
                    sh "docker-compose build api"
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
                sh "docker-compose up -d"
            }
        }
    }
}