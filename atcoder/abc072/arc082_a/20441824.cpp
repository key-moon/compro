// detail: https://atcoder.jp/contests/abc072/submissions/20441824
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
  vector<int> cnt(100001);
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    cnt[a]++;
  }
  int res = 0;
  for (int i = 1; i < 100000; i++) {
    chmax(res, cnt[i - 1] + cnt[i] + cnt[i + 1]);
  }
  cout << res << endl;
}
