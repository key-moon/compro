// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2856/judge/4933976/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  int n, h, w;
  cin >> n >> h >> w;
  vector<bool> v(w * n);
  for (int i = 0; i < n; i++){
    int a;
    cin >> a;
    int st = i % 2 == 0 ? i * w + a : i * w - a;
    for (int j = 0; j < w; j++){
      v[st + j] = true;
    }
  }
  int res = 0;
  for (int i = 0; i < v.size(); i++){
    if (!v[i]) res += h;
  }
  cout << res << endl;
}

