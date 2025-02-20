FROM openjdk:21-jdk
WORKDIR /app
COPY target/my-java-gateway-1.0-SNAPSHOT.jar gateway.jar
ENTRYPOINT ["java", "-jar", "gateway.jar"]
