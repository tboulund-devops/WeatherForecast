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
                }
                sh "docker-compose --env-file config/Test.env build api"
            }
        }
        stage("Build frontend") {
            when {
                changeset "Web/**"
            }
            steps {
                sh "docker-compose --env-file config/Test.env build web"
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
                        sh "docker-compose --env-file config/Test.env down"
                    }
                    finally { }
                }
            }
        }
        stage("Deploy") {
            steps {
                sh "docker-compose --env-file config/Test.env up -d"
            }
        }
        stage("Push to registry") {
            steps {
                sh "docker-compose --env-file config/Test.env push"
            }
        }
        post {
            always {
                withCredentials([string(credentialsId: 'DiscordWebhookURL', variable: 'WEBHOOK_URL')]) {
                    discordSend description: "Jenkins Pipeline Build", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: "${WEBHOOK_URL}"
                }
            }
        }
    }
}