class Program {
  static void Main() {
    int[,] arr = {{1,3},{2,6},{8,10},{15,18}};

    List<List<int>> ans = app.Solution.MergeIntervals(arr);
    foreach (var row in ans) {
      foreach (var element in row) {
        Console.Write(element + " ");
      }
      Console.WriteLine();
    }
    // 1 6
    // 8 10
    // 15 18
  }
}

namespace app{
  public class Solution {
    public static List<List<int>> MergeIntervals(int[,] inputArr) {
      // result 為最後 return 的陣列
      // previous 為上一個內層陣列的值
      List<List<int>> result = [];
      List<int> previous = [];

      // 排序二維陣列，依照每個內層陣列的首個數字，由小到大排序陣列 (bubble sort)
      for (int i = 0; i < inputArr.GetLength(0) - 1; i++) {
        for (int j = 0; j < inputArr.GetLength(0) - i - 1; j++) {
          if (inputArr[j, 0] > inputArr[j + 1, 0]) {
            int temp0 = inputArr[j, 0];
            int temp1 = inputArr[j, 1];
            inputArr[j, 0] = inputArr[j + 1, 0];
            inputArr[j, 1] = inputArr[j + 1, 1];
            inputArr[j + 1, 0] = temp0;
            inputArr[j + 1, 1] = temp1;
          }
        }
      }

      // result 先放入 inputArr 內層首個陣列
      // 開始依序與 inputArr 內層陣列做比較，有重疊就合併 (改變 result 的最後一個陣列值)，沒重疊就新增進 result
      for (int i = 0; i < inputArr.GetLength(0); i++) {
        if (i == 0) {
          previous = [inputArr[i,0],inputArr[i,1]];
          result.Add(previous);
        } else {
          if (previous[1] >= inputArr[i,0]) {
            if (previous[1] <= inputArr[i,1]) {
              previous = [previous[0], inputArr[i,1]];
              result[^1] = previous;
            }
          } else {
            previous = [inputArr[i,0],inputArr[i,1]];
            result.Add(previous);
          }
        }
      }

      return result;
    }
  }
}
