// detail: https://atcoder.jp/contests/abc132/submissions/20435348
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  vector<int> d(n);
  for (int i = 0; i < n; i++) {
    cin >> d[i];
  }
  sort(d.begin(), d.end());
  cout << max(d[n / 2] - d[n / 2 - 1], 0) << endl;
}
