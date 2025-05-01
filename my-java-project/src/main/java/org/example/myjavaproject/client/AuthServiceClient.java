package org.example.myjavaproject.client;

import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;
import reactor.core.publisher.Mono;
import java.util.HashMap;
import java.util.Map;

/**
 * 授权RPC调用
 */
@Service
public class AuthServiceClient {
    private final WebClient webClient;
    private static final String AUTH_VALID = "/api/auth/validate";

    public AuthServiceClient(WebClient.Builder webClientBuilder) {
        this.webClient = webClientBuilder.baseUrl("http://auth") // 使用 Consul 解析 "auth"
                .defaultHeader("User-Agent", "MyCustomClient")
                .build();
    }

    public Mono<Map<String, Object>> valid(String token) {
        Map<String, String> requestBody = new HashMap<>();
        requestBody.put("token", token);

        return this.webClient
                .post()
                .uri(AUTH_VALID)
                .contentType(MediaType.APPLICATION_JSON)
                .bodyValue(requestBody) // ✅ 直接传递 Token
                .retrieve()
                .onStatus(HttpStatus.UNAUTHORIZED::equals, clientResponse -> Mono.empty())
                .bodyToMono(new ParameterizedTypeReference<Map<String, Object>>() {
                })
                .doOnError(e -> {
                    Map.of("message", "认证失败","status", 401);
                })
                .defaultIfEmpty(Map.of("message", "认证失败")); // ✅ 处理空响应，返回默认值
    }


}
