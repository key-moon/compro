// detail: https://atcoder.jp/contests/code-festival-2014-qualb/submissions/26553346
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  string s1, s2, s3;
  cin >> s1 >> s2 >> s3;
  var get_kinds = [](string s) {
    vector<int> kinds(26);
    for (var&& c : s) {
      kinds[c - 'A']++;
    }
    return kinds;
  };
  var kinds1 = get_kinds(s1);
  var kinds2 = get_kinds(s2);
  var kinds3 = get_kinds(s3);
  var n = (int)s1.size();
  int total_diff_min = 0;
  int total_diff_max = 0;
  for (var i = 0; i < 26; i++) {
    var cnt1 = kinds1[i];
    var cnt2 = kinds2[i];
    var cnt3 = kinds3[i];
    if (cnt1 + cnt2 < cnt3) goto impossible;
    // min
    {
      var from_1 = min(cnt1, cnt3);
      var from_2 = cnt3 - from_1;
      total_diff_min += from_2 - from_1;
    }
    // max
    {
      var from_2 = min(cnt2, cnt3);
      var from_1 = cnt3 - from_2;
      total_diff_max += from_2 - from_1;
    }
  }
  if (total_diff_min <= 0 && 0 <= total_diff_max) {
    cout << "YES" << endl;
    return 0;
  }
impossible:;
  cout << "NO" << endl;
}
