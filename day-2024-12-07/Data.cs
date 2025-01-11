namespace day_2024_12_07;

public record Data(List<Equation> Equations);
public record Equation(List<long> Numbers, long Result);