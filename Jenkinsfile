pipeline{
    agent any
    stages{
        stage("Build API"){
            steps{
                sh "========executing A========"
            }
            post{
                always{
                    echo "========always========"
                }
                success{
                    echo "========A executed successfully========"
                }
                failure{
                    echo "========A execution failed========"
                }
            }
        }
        stage("Unit Tests") {
            steps {
                // ...
            }
        }
        stage("Deploy") {
            parallel {
                stage("Frontend") {
                    dir("Web") {
                        sh "docker build -t weather-web ."
                        sh "docker rm -f weather-web-container"
                        sh "docker run --name weather-web-container "
                    }
                }
            }
        }
    }
    post{
        always{
            echo "========always========"
        }
        success{
            echo "========pipeline executed successfully ========"
        }
        failure{
            echo "========pipeline execution failed========"
        }
    }
}