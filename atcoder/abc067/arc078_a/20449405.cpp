// detail: https://atcoder.jp/contests/abc067/submissions/20449405
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
  vector<ll> a(n);
  for (int i = 0; i < n; i++) cin >> a[i];
  var sum = accumulate(a.begin(), a.end(), 0LL);
  ll curSum = 0;
  ll res = LLONG_MAX;
  for (int i = 0; i < n - 1; i++) {
    curSum += a[i];
    var remain = sum - curSum;
    chmin(res, abs(curSum - remain));
  }
  cout << res << endl;
}
