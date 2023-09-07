# CSharpSummaryShortener
C#: 3 lines summary -> 1 line summary

# Sample IO
## Input
```
namespace SampleNamespace;
public class SampleClass
{
    /// <summary>
    /// SampleText A
    /// </summary>
    public int SampleProperty { get; set; }

    /// <summary>
    /// SampleText B
    /// This summary is not shortened
    /// </summary>
    public class SampleInnerClass
    {
        /// <summary>
        /// SampleText C
        /// </summary>
        public int SampleInnerProperty { get; set; }
    }
}
```

## Output
```
namespace SampleNamespace;
public class SampleClass
{
    /// <summary> SampleText A </summary>
    public int SampleProperty { get; set; }

    /// <summary>
    /// SampleText B
    /// This summary is not shortened
    /// </summary>
    public class SampleInnerClass
    {
        /// <summary> SampleText C </summary>
        public int SampleInnerProperty { get; set; }
    }
}
```
