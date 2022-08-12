# API-Hook

> Basic example usage of API Hooking in C#.

Can be used in many different ways such as the example of blocking and alerting of MessageBox calls.

![ScreenShot](https://media.discordapp.net/attachments/1005173005426634802/1007318775504326676/unknown.png)

```ruby
new Hook(
    WinAPI.GetProcAddress(user32, "MessageBoxW"),
    Marshal.GetFunctionPointerForDelegate((MessageBoxDelegate)MessageBox)
).Enable();
```
