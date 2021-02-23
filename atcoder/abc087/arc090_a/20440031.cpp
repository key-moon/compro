// detail: https://atcoder.jp/contests/abc087/submissions/20440031
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
  ll mx = INT64_MIN;
  vector<int> a1(n);
  vector<int> a2(n);
  for (int i = 0; i < n; i++) cin >> a1[i];
  for (int i = 0; i < n; i++) cin >> a2[i];
  var sum2 = accumulate(a2.begin(), a2.end(), 0);
  int sum1 = 0;
  int res = 0;
  for (int i = 0; i < n; i++) {
    sum1 += a1[i];
    chmax(res, sum1 + sum2);
    sum2 -= a2[i];
  }
  cout << res << endl;
}
