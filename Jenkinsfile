pipeline{
    agent any
    stages{
        stage("Build API") {
            when {
                anyOf {
                    changeset "API/**"
                    changeset "BLL/**"
                    changeset "DAL/**"
                }
            }
            steps{
                dir("API") {
                    sh "dotnet build --configuration Release"
                    sh "docker-compose build api"
                }
            }
        }
        stage("Build frontend") {
            when {
                changeset "Web/**"
            }
            steps {
                dir("Web") {
                    sh "docker-compose build web"
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
    post {
        always {
            discordSend description: "Jenkins Pipeline Build", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: "https://discord.com/api/webhooks/951750229483462676/asT_twizohdYRp8o1dRIiLmCHD4lPPn8t1pN26-IsNY4dZLGS7m7d22hlGDoWgxAuzrQ"
        }
    }
}