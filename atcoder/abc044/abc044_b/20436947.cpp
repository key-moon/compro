// detail: https://atcoder.jp/contests/abc044/submissions/20436947
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  vector<int> cnt(256);
  for (var&& c : s) cnt[c]++;
  cout << (count_if(cnt.begin(), cnt.end(), [](int val) { return val % 2; }) ? "No" : "Yes") << endl;
}
