using UnityEngine;

public abstract class Dice {
  protected int sides;

  public int Roll() {
    return Random.Range(1, sides + 1);
  }

  public int[] Roll(int quantity) {
    int[] results = new int[quantity];
    for(int i=0; i<quantity; i++) {
      results[i] = quantity;
    }
    return results;
  }

  public int Total(int quantity) {
    int total = 0;
    foreach(int result in Roll(quantity)) {
      total += result;
    }
    return total;
  }
}

public class D6: Dice {
  public D6() {
    sides = 6;
  }
}

public class D3: Dice {
  public D3() {
    sides = 3;
  }
}