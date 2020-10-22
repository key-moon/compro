// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1356/judge/4932319/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  int n;
  cin >> n;
  vector<int> a(n);
  for (int i = 0; i < n; i++){
    cin >> a[i];
  }
  set<int> s{};
  for (int i = 0; i < n; i++){
    int cur = 0;
    for (int j = i; j < n; j++){
      cur = cur * 10 + a[j];
      s.insert(cur);
      if (10000 <= cur) break;
    }
  }
  for (int i = 0; ; i++){
    if (!s.count(i)){
      cout << i << endl;
      return 0;
    }
  }
}


