namespace day_2024_12_05;

public record Data(List<Rule> Rules, List<Update> Updates);
public record Rule(int Left, int Right);
public record Update(List<int> Numbers);