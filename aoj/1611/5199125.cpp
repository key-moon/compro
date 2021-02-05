// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1611/judge/5199125/C++17
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;

int main() {
  int n;
  while (cin >> n, n){
    vector<int> a(n);
    for (var&& item : a) cin >> item;
    vector<vector<bool>> possible(n + 1, vector<bool>(n + 1));
    for (int i = 0; i <= n; i++) possible[i][i] = true;
    for (int l = 2; l <= n; l += 2){
      for (int i = 0; i <= n - l; i++){
        int j = i + l;
        possible[i][j] = 
          (possible[i][j - 2] and abs(a[j - 2] - a[j - 1]) <= 1) or 
          (possible[i + 1][j - 1] and abs(a[i] - a[j - 1]) <= 1) or 
          (possible[i + 2][j] and abs(a[i] - a[i + 1]) <= 1);
        for (int k = i; k <= j; k++){
          if (possible[i][k] and possible[k][j]) possible[i][j] = true;
        }
      }
    }
    vector<vector<int>> dp(n + 1, vector<int>(n + 1));
    for (int l = 0; l <= n; l++){
      for (int i = 0; i <= n - l; i++){
        int j = i + l;
        if (possible[i][j]) dp[i][j] = l;
        else{
          for (int k = i + 1; k < j; k++){
            chmax(dp[i][j], dp[i][k] + dp[k][j]);
          }
        }
      }
    }
    cout << dp[0][n] << endl;
  }
}

