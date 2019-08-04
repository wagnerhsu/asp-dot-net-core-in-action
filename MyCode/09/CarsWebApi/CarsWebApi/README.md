## 2019-08-04

- Xml formatter示例
  - 当Accept为`text/xml`返回xml内容，否则返回默认的json内容
- 如果显式以xml或json输出，不会接收定制的formatter。只有当输出一个具体类型如`IEnumerable<string>`这样的具体类型时，WebApi会自动根据Accept生成所需要的输出格式