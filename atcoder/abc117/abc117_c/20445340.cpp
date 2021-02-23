// detail: https://atcoder.jp/contests/abc117/submissions/20445340
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
  vector<int> x(m);
  for (int i = 0; i < m; i++) cin >> x[i];
  sort(x.begin(), x.end());
  vector<int> gaps(m - 1);
  for (int i = 0; i < m - 1; i++) {
    gaps[i] = x[i + 1] - x[i];
  }
  sort(gaps.begin(), gaps.end(), greater<int>());
  ll res = x.back() - x.front();
  for (int i = 0; i < min(n - 1, m - 1); i++) res -= gaps[i];
  cout << res << endl;
}
