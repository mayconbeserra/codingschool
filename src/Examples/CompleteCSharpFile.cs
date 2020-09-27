public class Person
{
    public string Name { get; set; }
    public string Description { get; set; } = "This is an extended description"
                + " and it can have one additional line";
    // this is the first comment
    // this is the second simple comment
    /*
    this should not count as code
    A little bit more of comments.
    */
}