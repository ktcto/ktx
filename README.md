# 开源ktx本机代理

## 使用场景

1、用于绑定 任意虚拟域名 到本机localhost任意端口号，用虚拟域名80或443端口开发调试本机的其它项目

2、可绑定虚拟域名到本机的其它项目，支持任意编程语言C# Java Go等、任意开发工具VS2022、VSCode、IntelliJ IDEA等

## 使用步骤

1、在本机C:\Windows\System32\drivers\etc目录（MacOS的hosts文件在 /etc/hosts ）
用记事本打开hosts文件，绑定虚拟域名：   
```
127.0.0.1 k1.t  
127.0.0.1 k2.t  
127.0.0.1 k3.t  
127.0.0.1 k4.t  
127.0.0.1 k5.t  
127.0.0.1 demo108.com  
127.0.0.1 demo308.com  
```
2、下载 [ktx.zip](https://dev.azure.com/ktcto/4a5cd319-ad3f-48d3-978e-cb3211658117/_apis/git/repositories/66062f6e-7132-44e4-b733-518b0fefdd38/items?path=/zip/ktx.zip&download=true)
解压后，点击 <b><font color=green>ktx_start.bat</font></b> 或者 <b><font color=green>ktx.exe</font></b> 运行，
如果80、443端口已被IIS占用，需要先在任务管理器的服务列表中 右键停止 <b>W3SVC服务</b>（IIS网站服务），才能运行本项目
（MacOS安装 https://dot.net 7.0后 <b>dotnet ktx.dll</b> 运行本项目）

3、如果运行失败，用管理员权限运行cmd命令查看本机80、443端口被哪个进程占用，关闭对应进程
```
netstat -ano | findstr 0.0.0.0:80  
netstat -ano | findstr 0.0.0.0:443
TASKKILL /F /IM "dotnet.exe" /T
TASKKILL /F /PID  进程Id /T
``` 
 
4、运行本项目，浏览器访问 http://k1.t 和 http://k2.t 可以看到本机代理到不同的网站

5、修改配置文件 <b><font color=blue>appsettings.json</font></b> 指向本机其它项目localhost:端口 及 你自定义的虚拟域名，  
修改本机hosts文件增加自定义的虚拟域名，重新运行本项目，就可以用你的虚拟域名访问本机其它项目，用于开发调试等场景

## 技术原理

1、ktx基于微软开源YARP反向代理组件，监听80、443端口，配置虚拟域名反向代理到本机其它项目的端口号 https://github.com/microsoft/reverse-proxy    

2、https://microsoft.github.io/reverse-proxy/articles/config-files.html

## KT开源社区

[ktcto.com](https://ktcto.com)

1、ktx本机代理：绑定虚拟域名用于开发调试    
https://dev.azure.com/ktcto/ktx  
https://gitcode.net/ktcto/ktx  
https://gitee.com/ktcto/ktx    

## 开源协议

KT开源社区 ktcto.com 使用[MIT开源协议](https://opensource.org/license/mit)



