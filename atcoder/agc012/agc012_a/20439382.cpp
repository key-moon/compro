// detail: https://atcoder.jp/contests/agc012/submissions/20439382
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
  vector<int> a(n * 3);
  for (int i = 0; i < n * 3; i++) cin >> a[i];
  sort(a.begin(), a.end(), greater<int>());
  ll res = 0;
  for (int i = 0; i < n; i++) res += a[i * 2 + 1];
  cout << res << endl;
}
