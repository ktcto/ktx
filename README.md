# 开源ktx本机代理

## 使用场景

This project uses Microsoft open-source reverse-proxy YARP to bind virtual domain names 
to any localhost:port for testing and debugging local projects.

用于绑定虚拟域名到本机localhost端口号，方便开发调试本机各项目
（支持各种编程语言C# Java Go……各种开发工具VS VSCode IDEA）

## 使用步骤

1、在本机C:\Windows\System32\drivers\etc目录（MacOS在 /etc/hosts ）
用记事本打开hosts文件，绑定虚拟域名：   
```
127.0.0.1 k1demo.tf  
127.0.0.1 k2demo.tf  
```
2、cmd命令行或Mac终端运行 <b><font color=green>dotnet --info</font></b> 查看是否已安装 [.NET 7.0](https://dot.net) ，
如果提示dotnet命令不存在，请先安装 [.NET 7.0](https://dot.net)

3、下载 [ktx.zip](https://gitcode.net/ktcto/ktx/-/raw/master/zip/ktx.zip)
解压后，点击 <b><font color=green>ktx_start.bat</font></b> 运行本项目（MacOS终端运行 <b><font color=green>dotnet ktx.dll</font></b>），
如果80端口已被IIS或其它进程占用，报错信息：
```
dotnet ktx.dll
Unhandled exception. System.Net.Sockets.SocketException (10013): 以一种访问权限不允许的方式做了一个访问套接字的尝试。
```
请在任务管理器的服务列表中 右键停止 <b>W3SVC服务</b>（IIS网站服务），重新运行本项目，看到以下信息表示运行成功：
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://[::]:80
```

4、如果运行失败，管理员权限运行cmd命令查看本机80、443端口被哪个进程占用，关闭对应进程
```
netstat -ano | findstr 0.0.0.0:80  
netstat -ano | findstr 0.0.0.0:443
TASKKILL /F /IM "dotnet.exe" /T
TASKKILL /F /PID  进程Id /T
``` 
MacOS 终端查看本机80、443端口被哪个进程占用，关闭对应进程
```
sudo  lsof  -i  :80
sudo  lsof  -i  :443
sudo  kill  -9  进程Id
```

5、成功运行本项目后，浏览器访问 http://k1demo.tf 和 http://k2demo.tf 可以看到本机代理到不同的网站

6、修改配置文件 <b><font color=blue>appsettings.json</font></b> 指向本机其它项目localhost:端口，
可增加自定义虚拟域名（同时修改hosts文件），重新运行本项目，就可以用虚拟域名开发调试本机各项目了

## 技术原理

1、ktx基于微软开源YARP反向代理组件，监听80、443端口，配置虚拟域名反向代理到本机其它项目的端口号 https://github.com/microsoft/reverse-proxy    

2、https://microsoft.github.io/reverse-proxy/articles/config-files.html

## KT开源社区 [ktcto.com](https://ktcto.com)

1、ktx本机代理：绑定虚拟域名用于开发调试    
https://dev.azure.com/ktcto/ktx  
https://gitcode.net/ktcto/ktx  
https://gitee.com/ktcto/ktx    
https://github.com/ktcto/ktx    

## 开源协议

KT开源社区 [ktcto.com](https://ktcto.com) 使用[MIT开源协议](https://opensource.org/license/mit)

## 免责声明

<font color=black>用户使用本站资源所产生的一切问题或违法行为，
KT开源社区 不承担 任何责任</font>



