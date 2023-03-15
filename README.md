## 自用 MDUI Blazor组件包
自用，暂无文档  
Pages/_Host.cshtml加入：
```
<link href="_content/JGLB.MDUI/css/mdui.min.css" rel="stylesheet" />
<script src="_content/JGLB.MDUI/js/mdui.min.js"></script>
<script src="_content/JGLB.MDUI/js/mdui.blazor.js"></script>
```
_Imports.razor加入：
```
@using JGLB.MDUI
```
布局时使用Body组件作为最外层以获得最佳主题适配效果 
示例：
```
<Body PrimaryColor="Color.Teal" AccentColor="Color.DeepOrange">
    <NavMenu />
    <Container BGColor="Color.Theme" BGDegree="Degree.The100" Fluid>
        <Card BGColor="Color.Theme" BGDegree="Degree.The200">
            <CardContent>
                @Body
            </CardContent>
        </Card>
    </Container>
</Body>
```

MDUI:[https://github.com/zdhxiong/mdui](https://github.com/zdhxiong/mdui)