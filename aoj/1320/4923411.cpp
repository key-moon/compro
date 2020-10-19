// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1320/judge/4923411/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int main(){
  cin.sync_with_stdio(false);
  // 入力
  int n;
  cin >> n;
  if (n == 0) return 0;
  vector<string> s(n);
  for (int i = 0; i < n; i++){
    cin >> s[i];
  }

  // [i][j] := s[i]の後にs[j]を連結した時
  vector<vector<int>> overrap(n, vector<int>(n));
  for (int i = 0; i < n; i++){
    for (int j = 0; j < n; j++){
      for (int st = 0; st <= s[i].size(); st++){
        for (int ii = st, ji = 0; ii < s[i].size() && ji < s[j].size(); ii++, ji++){
          if (s[i][ii] != s[j][ji]) goto no;
        }
        overrap[i][j] = max(0, st + (int)s[j].size() - (int)s[i].size());
        break;
        no:;
      }
    }
  }

  // dp[id][last] 最初がfstで次がlast
  vector<vector<int>> dp(1 << n, vector<int>(n, INT32_MAX / 2));
  for (int i = 0; i < n; i++){
    dp[1 << i][i] = s[i].size();
  }
  // 小さいIDから埋める 配る
  for (int i = 1; i < (1 << n); i++){
    for (int prev = 0; prev < n; prev++){
      if (!(i >> prev & 1)) continue;
      for (int nxt = 0; nxt < n; nxt++){
        if (i >> nxt & 1) continue;
        if (overrap[prev][nxt] == 0){
          chmin(dp[i | (1 << nxt)][prev], dp[i][prev]);
        }
        else{
          chmin(dp[i | (1 << nxt)][nxt], dp[i][prev] + overrap[prev][nxt]);
        }
      }
    }
  }
  int mn = INT32_MAX;
  for (int i = 0; i < n; i++){
    chmin(mn, dp.back()[i]);
  }
  cout << mn << endl;
  main();
}

