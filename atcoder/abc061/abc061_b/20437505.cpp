// detail: https://atcoder.jp/contests/abc061/submissions/20437505
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m;
  cin >> n >> m;
  vector<int> res(n);
  for (int i = 0; i < m; i++) {
    int s, t;
    cin >> s >> t;
    res[s - 1]++; res[t - 1]++;
  }
  for (int i = 0; i < n; i++) {
    cout << res[i] << endl;
  }
}
