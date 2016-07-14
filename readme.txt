
原由：T4模版不易调试，则改用.NET的模板引擎来生成代码

1.NET的模板引擎
  1.1NVelocity
  1.2RazorEngine

  --
  RazorEngine 主要原因是有代码提示
  地址：
  http://razorengine.codeplex.com/
  https://github.com/Antaris/RazorEngine
  参考文档：
  1.1抛弃NVelocity，来玩玩Razor	http://www.cnblogs.com/huangxincheng/p/3644313.html
  1.2RazorEngine官网	https://antaris.github.io/RazorEngine/ 	https://github.com/Antaris/RazorEngine
  1.3ASP.NET Razor-标记	http://www.w3school.com.cn/aspnet/razor_intro.asp

  ------------------------------------------------------------------------------------------------
  写法：1
      @foreach (Column c in table.Columns)
    {
        string temp = string.Format(@"
            private String {0};
            public String {1}
            {{
                get {{ return {0}; }}
                set {{ {0} = value; }}
            }}
        ", c.LowerColumnName, c.UpColumnName);

        @(temp)
    }

   写法：2
   1.1通过<h1><h2><h3>来代表代码的嵌套
   1.2
    @foreach (Column c in table.Columns)
    {
        <h1>
            private String @c.LowerColumnName;

            public String @c.UpColumnName
            {
            get { return @c.LowerColumnName; }
            set { @c.LowerColumnName = value; }
            }

        </h1>
    }
   1.3通过正则再删除<h1>

------------------------------------------------------------------------------------------------
  Dao中包括的方法：
  1.Add
  2.DeleteById
  3.UpdateById
  4.FindById
  5.FindList
  6.FindListByPage
  7.Count