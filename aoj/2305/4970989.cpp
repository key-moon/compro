// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2305/judge/4970989/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n;
  cin >> n;
  vector<int> a(n);
  for (int i = 0; i < n; i++) cin >> a[i];
  double valid = 1, invalid = 1e-10;
  for (int iter = 0; iter < 100; iter++){
    var mid = (valid + invalid) / 2;
    //var mid = 0.008935824532900;
    //0.008935824532900
    vector<int> cur{};
    var init = max((int)floor(a[0] - a[0] * mid), 1);
    var end = (int)ceil(a[0] + a[0] * mid);
    for (int i = init; i <= end; i++){
      var ratio = abs((double)(a[0] - i)) / a[0];
      if (mid < ratio) continue;
      cur.emplace_back(i);
    }
    for (int i = 1; i < n; i++){
      var begin = a[i] - a[i] * mid;
      var end = a[i] + a[i] * mid;
      vector<int> nxt{};
      for (int i = 0; i < n; i++){
        for (var&& elem : cur){
          var num = elem;
          while (num < begin) num += elem;
          while (num <= end){
            nxt.emplace_back(num);
            num += elem;
          }
        }
      }
      sort(nxt.begin(), nxt.end());
      nxt.erase(unique(nxt.begin(), nxt.end()), nxt.end());
      cur = move(nxt);
    }
    if (!cur.empty()) valid = mid;
    else invalid = mid;
  }
  cout << fixed << setprecision(15);
  cout << valid << endl;
  return 0;
}

