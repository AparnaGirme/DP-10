public class Solution {
    // TC => O(kn)
    // SC => O(kn)
    public int SuperEggDrop(int k, int n) {
        if(n == 0 || k == 0){
            return 0;
        }
        int[][] dp = new int[n+1][];
        for(int i = 0; i <= n; i++){
            dp[i] = new int[k+1];
        }
        int attempts = 0;
        while(dp[attempts][k] < n){
            attempts++;
            for(int j = 1; j < k + 1; j++){
                dp[attempts][j] = 1 + dp[attempts - 1][j - 1] + dp[attempts - 1][j];
            }
        }
        return attempts;
    }
    // SC => O(kn^2)
    // TC => O(kn)
    public int SuperEggDrop1(int k, int n) {
        if(n == 0 || k == 0){
            return 0;
        }

        int[][] dp = new int[k+1][];
        for(int i = 0; i <= k; i++){
            dp[i] = new int[n+1];
        }

        for(int j = 1; j < n+1; j++){
            dp[1][j] = j;
        }

        for(int i = 2; i < k+1; i++){
            for(int j = 1; j < n+1; j++){
                dp[i][j] = Int32.MaxValue;
                for(int f = 1; f <= j; f++){
                    dp[i][j] = Math.Min(dp[i][j], 1 + Math.Max(dp[i-1][f-1], dp[i][j-f]));
                }
            }
        }
        return dp[k][n];
    }
}