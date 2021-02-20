// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2823/judge/5238491/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m;
  while (cin >> n >> m, n) {
    vector<int> maxv(n);
    for (int i = 0; i < n; i++) {
      int d, v;
      cin >> d >> v;
      chmax(maxv[d - 1], v);
    }
    cout << accumulate(maxv.begin(), maxv.end(), 0) << endl;
  }
}

