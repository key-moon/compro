// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2007/judge/4936339/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

bool hasprev = false;

signed main() {
  int n;
  cin >> n;
  if (n == 0) return 0;
  
  if (hasprev) cout << endl;
  hasprev = true;

  vector<int> a(4);
  vector<int> units{ 10, 50, 100, 500 };
  cin >> a[0] >> a[1] >> a[2] >> a[3];
  int curmin = INT_MAX;
  vector<int> res(4);
  for (int i = 0; i <= a[0]; i++){
    for (int j = 0; j <= a[1]; j++){
      for (int k = 0; k <= a[2]; k++){
        for (int l = 0; l <= a[3]; l++){
          vector<int> cur{i, j, k, l};
          var price = i * 10 + j * 50 + k * 100 + l * 500;
          var ret = price - n;
          if (ret < 0) continue;
          int remain = a[0] + a[1] + a[2] + a[3] - i - j - k - l;
          for (int i = 3; i >= 0; i--){
            var r = ret / units[i];
            if (r != 0 && cur[i] != 0) goto end;
            remain += r;
            ret = ret % units[i];
          }
          if (remain < curmin){
            res = move(cur);
            curmin = remain;
          }
          end:;
        }
      }
    }
  }
  for (int i = 0; i < 4; i++){
    if (res[i] == 0) continue;
    cout << units[i] << " " << res[i] << endl;
  }
  main();
}

