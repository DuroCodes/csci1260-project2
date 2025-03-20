namespace Project2.Models;

public record Note(int Id, string Title, string Content, List<Reference> References);