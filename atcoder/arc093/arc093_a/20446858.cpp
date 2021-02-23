// detail: https://atcoder.jp/contests/arc093/submissions/20446858
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
  vector<int> a(n + 2);
  ll sum = 0;
  for (int i = 1; i <= n; i++) {
    cin >> a[i];
    sum += abs(a[i] - a[i - 1]);
  }
  sum += abs(a[n + 1] - a[n]);
  for (int i = 1; i <= n; i++) {
    ll res = sum;
    res -= abs(a[i] - a[i - 1]);
    res -= abs(a[i] - a[i + 1]);
    res += abs(a[i + 1] - a[i - 1]);
    cout << res << endl;
  }
}
