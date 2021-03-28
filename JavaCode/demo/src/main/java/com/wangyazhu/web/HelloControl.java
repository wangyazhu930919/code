package com.wangyazhu.web;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HelloControl {
    @RequestMapping("/hello")
    public String hello() {
        System.out.printf("有请求进来");
        return "hello Spring Boot";
    }
}
