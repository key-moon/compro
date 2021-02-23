// detail: https://atcoder.jp/contests/abc121/submissions/20434827
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m, c;
  cin >> n >> m >> c;
  vector<int> b(m);
  for (int i = 0; i < m; i++) cin >> b[i];
  int res = 0;
  for (int i = 0; i < n; i++) {
    int cnt = c;
    for (int j = 0; j < m; j++) {
      int a;
      cin >> a;
      cnt += a * b[j];
    }
    if (cnt > 0) res++;
  }
  cout << res << endl;
}
